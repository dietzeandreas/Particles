function setX3DOMParticles() {
    // pos
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
    console.log(coordinateObj.length);
    coordinateObj.length = ps.particleArray.length;
    console.log(coordinateObj.length);
    for (var i = 0; i < coordinateObj.length; i++)
        coordinateObj[i] = ps.particleArray[i].position;
    coordDOMNode.releaseFieldRef("point");

    // size
    var particleSetDOMNode = document.getElementById("ps");
    var sizeObj = particleSetDOMNode.requestFieldRef("size");
    sizeObj.length = ps.particleArray.length;
    for (var i = 0; i < sizeObj.length; i++)
        sizeObj[i] = ps.particleArray[i].scale;
    particleSetDOMNode.releaseFieldRef("size");

    // color
    var colorDOMNode = document.getElementById("col");
    var colorObj = colorDOMNode.requestFieldRef("color");
    colorObj.length = ps.particleArray.length;
    for (var i = 0; i < colorObj.length; i++)
        colorObj[i] = ps.particleArray[i].color;
    colorDOMNode.releaseFieldRef("color");
}

function newX3dParticle (particle){
    // pos
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
//    console.log(coordinateObj.length);
    coordinateObj.length = ps.particleArray.length;
//    console.log(coordinateObj.length);
//    for (var i = 0; i < coordinateObj.length; i++)
        coordinateObj[coordinateObj.length-1] = particle.getPosition();
    coordDOMNode.releaseFieldRef("point");

    // size
    var particleSetDOMNode = document.getElementById("ps");
    var sizeObj = particleSetDOMNode.requestFieldRef("size");
    sizeObj.length = ps.particleArray.length;
//    for (var i = 0; i < sizeObj.length; i++)
        sizeObj[sizeObj.length-1] = particle.getScale();
    particleSetDOMNode.releaseFieldRef("size");

    // color
    var colorDOMNode = document.getElementById("col");
    var colorObj = colorDOMNode.requestFieldRef("color");
    colorObj.length = ps.particleArray.length;
//    for (var i = 0; i < colorObj.length; i++)
        colorObj[colorObj.length-1] = particle.getColor();
    colorDOMNode.releaseFieldRef("color");
}

function setX3dPosition (particle, index){
    // pos
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
//    console.log(coordinateObj.length);
//    coordinateObj.length = ps.particleArray.length;
//    console.log(coordinateObj.length);
//    for (var i = 0; i < coordinateObj.length; i++)
        coordinateObj[index] = particle.getPosition();
    coordDOMNode.releaseFieldRef("point");
}

function setX3dColor (particle, index){
    // color
    var colorDOMNode = document.getElementById("col");
    var colorObj = colorDOMNode.requestFieldRef("color");
//    colorObj.length = ps.particleArray.length;
//    for (var i = 0; i < colorObj.length; i++)
        colorObj[index] = particle.getColor();
    colorDOMNode.releaseFieldRef("color");
}