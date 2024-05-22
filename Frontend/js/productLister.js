import { $ } from './jQueryish.js';
import { fetchEasy } from './fetchEasy.js';

export async function productLister(onlyProducts = false) {
  let categories = await fetchEasy('/api/categories');
  let products = await fetchEasy('/api/products');
  products = products.map(x => ({
    ...x,
    catName: categories.find(y => y.id === x.categoryId).name
  }));
  let productsToShow = products.filter(
    x => x.catName === categoryToShow || !categoryToShow);
  let element = onlyProducts ? $('.products')[0] : $('article')[0];
  element.innerHTML = /*html*/`
    ${onlyProducts ? '' : /*html*/`<label>Välj kategori:
      <select id="categories">
        <option value="">Alla</option>
        ${categories.map(x => /*html*/`<option>${x.name}</option>`).join('')}
      </select>
    </label>`}
    <div class="products">
      ${productsToShow.map(x => /*html*/`<div class="product"
        style="background-image:url(/images/products/${x.id}.webp)">
          <h3 class="name">${x.name}</h3>
          <p class="description">${x.description}</p>
          <p class="price">Pris: ${x.price} kr</p>
        </div>`).join('')}
    </div>
  `;
}

let categoryToShow = "";
$('select').change(() => {
  categoryToShow = $('select')[0].value;
  $('.products')[0].innerHTML = '';
  productLister(true);
});