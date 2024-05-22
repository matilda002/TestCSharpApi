import { marked } from "https://cdn.jsdelivr.net/npm/marked/lib/marked.esm.js";

export async function fetchEasy(url, options = {}) {
  let isText = !url.endsWith('.json') || !url.includes('.');
  if (url.includes('/api')) { isText = false; }
  let result = await (await fetch(url, options))[isText ? 'text' : 'json']();
  url.endsWith('.md') && (result = marked(result));
  isText && (result = await result.hydrate({
    import: async url =>
      await fetchEasy(url.includes('/') ? url : '/content/' + url)
  }).wait());
  if (url.endsWith('.md') || url.endsWith('.html')) {
    result = `<div id="${url.split('/').pop().split('.')[0]}">\n${result}\n</div>`;
  }
  return result;
}