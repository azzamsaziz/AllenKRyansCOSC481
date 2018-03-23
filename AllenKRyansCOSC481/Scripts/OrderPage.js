function visibility(i) {
	
	var itemGrp = "itemGroup";
	var iitemGrp = document.getElementById("ocount").value;

	

	for (var j = 1; j < iitemGrp; j++) {
		//alert(iitemGrp + j);
		document.getElementById(itemGrp + j).style.display = "none";
		//alert("j: "+itemGrp + j);
	}
	//alert("i: "+itemGrp + i);
	document.getElementById("" + itemGrp + i).style.display = "inline";
}