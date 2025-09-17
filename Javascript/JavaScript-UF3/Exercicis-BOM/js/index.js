const ls = localStorage;

ls.setItem("colorFons", "red");
console.log(ls.getItem("colorFons"));
ls.removeItem("colorFons");
