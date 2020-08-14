function hexToRgb(hexCode) {
    var patt = /^#([\da-fA-F]{2})([\da-fA-F]{2})([\da-fA-F]{2})$/;
    var matches = patt.exec(hexCode);
    var rgb = "rgb(" + parseInt(matches[1], 16) + "," + parseInt(matches[2], 16) + "," + parseInt(matches[3], 16) + ")";
    return rgb;
}

function hexToRgba(hexCode, opacity) {
    var patt = /^#([\da-fA-F]{2})([\da-fA-F]{2})([\da-fA-F]{2})$/;
    var matches = patt.exec(hexCode);
    var rgb = "rgba(" + parseInt(matches[1], 16) + "," + parseInt(matches[2], 16) + "," + parseInt(matches[3], 16) + "," + opacity + ")";
    return rgb;
}


function ChunkedData(data, chunkSize) {
    var chunkeddata = [];
    var listdata = [];

    for (x in data) {
        listdata.push(data[x])
        if ((parseInt(x, 10) + 1) % chunkSize == 0) {
            chunkeddata.push(listdata)
            listdata = [];
        }
    }
    if (listdata.length > 0) {
        chunkeddata.push(listdata)
        listdata = [];
    }

    return chunkeddata;
}

function csvJSON(csv, fields) {

    var lines = csv.split("\n");

    var result = [];

    var headers = lines[0].split(",");
    
    for (h in headers) {
        if(fields.indexOf(headers[h].trim()) < 0)
            throw "Error in header";
    }

    for (var i = 1; i < lines.length; i++) {

        var obj = {};
        var currentline = lines[i].split(",");

        if (currentline.length == headers.length) {
            for (var j = 0; j < headers.length; j++) {
                obj[headers[j]] = currentline[j];
            }
            obj["SubmitStatus"] = 0;
            result.push(obj);
        }
       

    }

    //return result; //JavaScript object
    return JSON.stringify(result); //JSON
}