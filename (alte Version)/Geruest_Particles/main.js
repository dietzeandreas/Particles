-> Leute.. hier spielt die Musik :-) <-




console.log("main.js running");

function CustomArray(size)
{
	// Create private array
	var a = [],
		i;

	// Insert rnd numbers
	for(i = 0; i < size; i++){
		a[i] = Math.floor((Math.random() * 100) + 1);
		console.log(i + " " + a[i]);
	}

	
	// Write all elements
	this.print = function(){
		// Write all elements without last
		for(i = 0; i < a.length - 1; i++){
			document.write(a[i] + ", ");   // document.getElementById("array").innerHTML = 
		}
		
		// Write last element
		document.write(a[a.length - 1] + "<br><br>");  // size - 1 
	}
	
	// Sort ascending
	this.sortASC = function(){
		a.sort(function(a, b){
			return a - b;
		})
	}
	
	// Sort descending
	this.sortDES = function(){
		a.sort(function(a, b){
			return b - a;
		})
	}
}

var randomNumbers = new CustomArray(100);
randomNumbers.print();
randomNumbers.sortASC();
randomNumbers.print();
randomNumbers.sortDES();
randomNumbers.print();

//------------------------

function Particle(position, scale, color){
	this.position = position;
	this.scale = scale;
	this.color = color;
}

Particle.prototype.getInfo = function(){
	console.log("pos: " + this.position + 
				" scale: " + this.scale + 
				" color: " + this.color);
};

//-------------------------------

function ParticleSystem(){
	this.particleArray = [];

    // Test particle class
	//var particle = new Particle(new x3dom.fields.SFVec3f(0.0, 0.0, 0.0),
								//new x3dom.fields.SFVec3f(0.0, 0.0, 0.0),
								//new x3dom.fields.SFColor(1, 1, 1));							
	//particle.getInfo();
}

ParticleSystem.prototype.addParticle = function(particle){
	this.particleArray.push(particle);
	//console.log("Particles in particleArray: " + this.particleArray.length);
}

ParticleSystem.prototype.getParticleArrayLength = function(){
	console.log("Particles in particleArray: " + this.particleArray.length);
}

ParticleSystem.prototype.showParticleArrayContent = function(){
	for(var i = 0; i < this.particleArray.length; i++){
		//console.log(this.particleArray[i].getInfo());
		console.log("Particle " + i + ": pos = " + this.particleArray[i].position + 
					" scale = " + this.particleArray[i].scale +
					" color = " + this.particleArray[i].color);
	}
}

var ps = new ParticleSystem();

var p = new Particle(new x3dom.fields.SFVec3f(0.0, 0.0, 0.0),
					 new x3dom.fields.SFVec3f(0.0, 0.0, 0.0),
					 new x3dom.fields.SFColor(1, 1, 1));
					 
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.addParticle(p);
ps.getParticleArrayLength();
ps.showParticleArrayContent();


