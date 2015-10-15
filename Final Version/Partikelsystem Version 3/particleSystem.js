console.log("particleSystem-Script active");

// constructor
function Particle(position, scale, color){
	this.position = position;
	this.scale = scale;
	this.color = color;
	//doit();
}

// public function
Particle.prototype.getInfo = function(){
	console.log("pos: " + this.position + 
				" scale: " + this.scale + 
				" color: " + this.color);
};

// public function
Particle.prototype.getPosition = function(){
//	console.log("pos: " + this.position);
        return this.position;
};

// public function
Particle.prototype.setPosition = function(position){
	console.log("pos:     " + this.position);
        this.position = position;        
	console.log("new pos: " + this.position);
};

// public function
Particle.prototype.getScale = function(){
//	console.log("size: " + this.scale);
        return this.scale;
};

// public function
Particle.prototype.getColor = function(){
//	console.log("color: " + this.color);
        return this.color;
};

// public function
Particle.prototype.setColor = function(color){
//	console.log("color: " + this.color);
        console.log("color:     " + this.position);
        this.color = color;
        console.log("new color: " + this.position);
};

// private function
function doit(){
	console.log("call doit");
}

//-------------------------------

// constructor 
function ParticleSystem(){

	// Globales particle Array
	this.particleArray = [];
}

// Füge particle dem globalem Array hinzu (particleArray);
ParticleSystem.prototype.addParticle = function(particle){
	this.particleArray.push(particle);
        
        
	//console.log("Particles in particleArray: " + this.particleArray.length);
};

// Gib die größe des Arrays als Zeichenkette zurück
ParticleSystem.prototype.getParticleArrayLength = function(){
	console.log("Particles in particleArray: " + this.particleArray.length);
};

// Gib den gesamten Inhalt des Arrays aus
ParticleSystem.prototype.showParticleArrayContent = function(){
	for(var i = 0; i < this.particleArray.length; i++){
		//console.log(this.particleArray[i].getInfo());
		console.log("Particle " + i + ": pos = " + this.particleArray[i].position + 
					" scale = " + this.particleArray[i].scale +
					" color = " + this.particleArray[i].color);
	}
};

// Gib das gesamte ParticleArray mit all seinem Inhalt
ParticleSystem.prototype.getParticleSystem = function(){
	return this.particleArray;
};

ParticleSystem.prototype.clear = function(){
	for (var i = 0; i < this.particleArray.length;){
            this.particleArray.pop();
        }
        
        
	//console.log("Particles in particleArray: " + this.particleArray.length);
};
