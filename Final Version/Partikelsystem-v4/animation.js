function startAnim()
{
    lastTimestamp = performance.now();
    animateParticles(lastTimestamp);
}

//"Zitterbewegung" der Partikel
function animateParticles(timestamp)
{
    var vx, vy, vz;
    var i;

    var dT = (timestamp - lastTimestamp) / 1000;
    lastTimestamp = timestamp;

    // manipulate position values over time (fake velocity added to position)
    var coordDOMNode = document.getElementById("pos");
    var coordinateObj = coordDOMNode.requestFieldRef("point");
    for (i = 0; i < coordinateObj.length; i++) {
        vx = Math.random() * 2 - 1;
        vy = Math.random() * 2 - 1;
        vz = Math.random() * 2 - 1;

        coordinateObj[i].x += vx * dT;
        coordinateObj[i].y += vy * dT;
        coordinateObj[i].z += vz * dT;
    }
    coordDOMNode.releaseFieldRef("point");

    // https://developer.mozilla.org/en-US/docs/Web/API/window.requestAnimationFrame
    requestAnimationFrame(animateParticles);   // -> update !!!!
}

//-------------------------------------------------------------------

//Grundlegende Animation
function animation()
{
    var index;

    for (index = 0; index < ps.particleArray.length; index++) {
        var particle = ps.particleArray[index];

        if (particle.position.z >= -collision_z_Point) {
            move(particle, index);
        } else {
            fall(particle, index);
        }
    }
}

//-------------------------------------------------------------------

//Bewegung der Partikel zur Leinwand
function move(particle, i)
{
    particle = ps.particleArray[i];

    //bewegung berechnen und zuweisen (Stueckweise)
    particle.position.x += flightDirections[i].x * 0.1;
    particle.position.y += flightDirections[i].y * 0.1;
    particle.position.z += flightDirections[i].z * 0.1;

    //console.log(particle.position.z);

    setX3dPosition(particle, i);
}

//-------------------------------------------------------------------

//runter fließen der Partikell an der Leinwand
function fall(particle, i) {
    var grenze = new x3dom.fields.SFVec3f(0.0, 3.15, 0.0);
    particle = ps.particleArray[i];

    if (particle.position.y >= grenze.y) {
        //bewegung berechnen und zuweisen (Stueckweise)
        //particle.position.x += Math.random() * 0.3;
        particle.position.y -= Math.random() * 0.2;
        //particle.position.z += 0.5;

        setX3dPosition(particle, i);
    } else {
        if (deletions[i] != 1) {
            partikelLoeschen(i);
            deletions[i] = 1;
            geloescht++;
            console.log(geloescht);
        }
    }
}