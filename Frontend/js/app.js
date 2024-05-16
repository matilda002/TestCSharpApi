
import './stringExtras.js';
import { $ } from './jQueryish.js';
import { fetchEasy } from './fetchEasy.js';
import { productLister } from './productLister.js';

// Read and parse the content
const content = await fetchEasy('/content/_content.md');
const bodySkeleton = content.extractHtml('#bodySkeleton');
const pages = content.extractHtml('[id$="Page"]');
const page404 = content.extractHtml('#page404');
const menuItems = pages.join('').extractHtml('h1');

// Add initial html for the site
$('body').html(bodySkeleton.hydrate({
  menu:
    menuItems.map((item, index) => /*html*/`
      <a href="/${index === 0 ? '' : item.kebabCase()}">
        ${item}
      </a>
    `).join('')
}));

// When we click on an internal link
// don't reload the page - instead use pushState
// and call showView
$('a[href^="/"]').click((el, event) => {
  event.preventDefault();
  history.pushState(null, '', el.attr('href'));
  showView();
});

// Show a view/"page"
function showView() {
  let route = location.pathname;
  // Find the corresponding menuItem index number to the href
  let index = route === '/' ? 0 :
    menuItems.findIndex(x => '/' + x.kebabCase() === route);
  // Replace the pages in the main element
  $('main article').html(pages[index] || page404);
  // Add the css class 'active' to the active menu item
  $('nav a').removeClass('active').eq(index).addClass('active');
  route === '/products' && productLister();
}

// Listen to the back/forward buttons - change view based on url
$(window).popstate(() => showView());

// Show the first view after a hard page load/reload
showView();