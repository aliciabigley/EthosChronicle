var express = require('express');
var app = express();

app.use(express.static('public'));

app.post('api/split', funciton(req, res){
var vid = req.body.vid.id;
var start = req.body.start.time;
var end = req.body.end.time


res.send("success")
}

//should i add uploader here?

function api(){
  $.ajax({
    url: url,
    method: 'get',
    data: {term: userInput},
    dataType: 'jsonp', //should this be the db?
    success: function(){
      displayResults();
    }
  });
}

var server = app.listen(3000, function(){
  console.log('Server listening on port 3000');
});
