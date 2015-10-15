//Übername des Partikelsystems auf X3D-Darstellung
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

//neuen Partikel erstellen X3D-Darstellung
function newX3dParticle(particle) {
    // pos
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
    coordinateObj.length = ps.particleArray.length;
    coordinateObj[coordinateObj.length - 1] = particle.getPosition();
    coordDOMNode.releaseFieldRef("point");

    // size
    var particleSetDOMNode = document.getElementById("ps");
    var sizeObj = particleSetDOMNode.requestFieldRef("size");
    sizeObj.length = ps.particleArray.length;
    sizeObj[sizeObj.length - 1] = particle.getScale();
    particleSetDOMNode.releaseFieldRef("size");

    // color
    var colorDOMNode = document.getElementById("col");
    var colorObj = colorDOMNode.requestFieldRef("color");
    colorObj.length = ps.particleArray.length;
    colorObj[colorObj.length - 1] = particle.getColor();
    colorDOMNode.releaseFieldRef("color");
}

//Position neu eintellen
function setX3dPosition(particle, index) {
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
    coordinateObj[index] = particle.getPosition();
    coordDOMNode.releaseFieldRef("point");
}

//Farbe neu einstellen
function setX3dColor(particle, index) {
    var colorDOMNode = document.getElementById("col");
    var colorObj = colorDOMNode.requestFieldRef("color");
    colorObj[index] = particle.getColor();
    colorDOMNode.releaseFieldRef("color");
}