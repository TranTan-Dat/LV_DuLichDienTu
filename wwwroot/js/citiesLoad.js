
var stateObject = {
      "TP Hồ Chí Minh": {
        "Quận 1": "Quận 1","Quận 2": [""],"Quận 3": [""],"Quận 4": [""],"Quận 11": [""],
      },
    }

    



    
    window.onload = function () {
      var countySel = document.getElementById("countySel"),
        stateSel = document.getElementById("stateSel"),
        thanhpho = document.getElementById("countySel").value;
      for (var dddl_quanhuyen in stateObject) {
        countySel.options[countySel.options.length] = new Option(dddl_quanhuyen, dddl_quanhuyen);
      }
      
      countySel.onchange = function () {
        stateSel.length = 1; // remove all options bar first
        // districtSel.length = 1; // remove all options bar first
        if (this.selectedIndex < 1) return; // done
        for (var dddl_tinhthanh in stateObject[this.value]) {
          stateSel.options[stateSel.options.length] = new Option(dddl_tinhthanh, dddl_tinhthanh);
        }
      }
      countySel.onchange(); // reset in case page is reloaded
      // stateSel.onchange = function () {
      //   districtSel.length = 1; // remove all options bar first
      //   if (this.selectedIndex < 1) return; // done
      //   var district = stateObject[countySel.value][this.value];
      //   for (var i = 0; i < district.length; i++) {
      //     districtSel.options[districtSel.options.length] = new Option(district[i], district[i]);
      //   }
      // }
    }