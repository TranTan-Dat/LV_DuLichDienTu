// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onload = function outVal() {
  let output_val = document.getElementById("output");
  
  const input_val = document.getElementById("input").innerText;

  var trimmedcontent = input_val.substring(1, input_val.length-2);
  output_val.innerHTML = trimmedcontent;
}

$(':radio').change(function() {
  console.log('New star rating: ' + this.value);
});