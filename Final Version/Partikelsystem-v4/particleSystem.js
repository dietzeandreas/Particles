console.log("particleSystem-Script active");

// constructor
function Particle(position, scale, color) {
    this.position = position;
    this.scale = scale;
    this.color = color;
}

// public function
Particle.prototype.getInfo = function () {
    console.log("pos: " + this.position +
            " scale: " + this.scale +
            " color: " + this.color);
};

//Rückgabe der Position
Particle.prototype.getPosition = function () {
    return this.position;
};

// Ändern der Position
Particle.prototype.setPosition = function (position) {
    console.log("pos:     " + this.position);
    this.position = position;
    console.log("new pos: " + this.position);
};

// Rückgabe der Skalierung
Particle.prototype.getScale = function () {
//	console.log("size: " + this.scale);
    return this.scale;
};

// Rückgabe der Farbe
Particle.prototype.getColor = function () {
//	console.log("color: " + this.color);
    return this.color;
};

// Ändern der Farbe
Particle.prototype.setColor = function (color) {
//	console.log("color: " + this.color);
    console.log("color:     " + this.position);
    this.color = color;
    console.log("new color: " + this.position);
};

//------------------------------------------------------------------------

// constructor 
function ParticleSystem() {

    // Globales particle Array
    this.particleArray = [];
}

// Füge particle dem globalem Array hinzu (particleArray);
ParticleSystem.prototype.addParticle = function (particle) {
    this.particleArray.push(particle);
};

// Gib die größe des Arrays als Zeichenkette zurück
ParticleSystem.prototype.getParticleArrayLength = function () {
    console.log("Particles in particleArray: " + this.particleArray.length);
};

// Gib den gesamten Inhalt des Arrays aus
ParticleSystem.prototype.showParticleArrayContent = function () {
    for (var i = 0; i < this.particleArray.length; i++) {
        console.log("Particle " + i + ": pos = " + this.particleArray[i].position +
                " scale = " + this.particleArray[i].scale +
                " color = " + this.particleArray[i].color);
    }
};

// Gib das gesamte ParticleArray mit all seinem Inhalt
ParticleSystem.prototype.getParticleSystem = function () {
    return this.particleArray;
};

//Leeren des kompletten Partikelsystems
ParticleSystem.prototype.clear = function () {
    for (var i = 0; i < this.particleArray.length; ) {
        this.particleArray.pop();
    }
};
