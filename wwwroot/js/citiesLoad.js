
var stateObject = {
      "TP Hồ Chí Minh": {
        "Quận 1": ["Quận 1"],"Quận 2": [""],"Quận 3": [""],"Quận 4": [""],"Quận 5": [""],"Quận 6": [""],"Quận 7": [""],"Quận 8": [""],"Quận 9": [""],"Quận 10": [""],"Quận 11": [""],"Quận 12": [""],"Quận Bình Tân": [""],"Quận Bình Thạnh": [""],"Quận Gò Vấp": [""],"Quận Phú Nhuận": [""],"Quận Tân Bình": [""],"Quận Tân Phú": [""],"Quận Thủ Đức": [""],"Huyện Bình Chánh": [""],"Huyện Cần Giờ": [""],"Huyện Củ Chi": [""],"Huyện Hóc Môn": [""],"Huyện Nhà Bè": [""],                                    
      },
      "TP Cần Thơ": {
        "Quận Ninh Kiều": [""],"Quận Cái Răng": [""],"Quận Bình Thủy": [""],"Quận Ô Môn": [""],"Huyện Phong Điền": [""],"Huyện Thốt Nốt": [""],"Huyện Cờ Đỏ": [""],"Huyện Vĩnh Thạnh": [""],"Huyện Thới Lai": [""],                                     
      },
      "TP Nha Trang":{"Đảo Hòn Tre":[]},
      "TP Đà Nẵng": {
        "Quận Cẩm Lệ": [""],"Quận Hải Châu": [""],"Quận Liên Chiểu": [""],"Quận Ngũ Hành Sơn": [""],"Quận Sơn Trà": [""],"Quận Thanh Khê": [""],"Huyện Hoàng Sa": [""],"Huyện Hòa Vang": [""],                                   
      },
      "TP Hội An": {
        "Phường Minh An": [""],"Phường Tân An": [""],"Phường Cẩm Phổ": [""],"Phường Thanh Hà": [""],"Phường Cẩm Châu": [""],"Phường Sơn Phong": [""],"Phường Cửa Đại": [""],"Phường Cẩm An": [""], "Xã Cẩm Hà": [""],"Xã Cẩm Kim": [""],"Xã Cẩm Thanh": [""],"Xã Tân Hiệp": [""],                    
      },

    }

    window.onload = function () {
      var countySel = document.getElementById("countySel"),
        stateSel = document.getElementById("stateSel");
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