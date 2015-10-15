    function startAnim() 
    {
        lastTimestamp = performance.now();
		animateParticles(lastTimestamp);
    }
    
    function animateParticles(timestamp) 
    {
        var vx, vy, vz;
        var i;
        
        var dT = (timestamp - lastTimestamp) / 1000;
        lastTimestamp = timestamp;
        
        // manipulate position values over time (fake velocity added to position)
        var coordDOMNode  = document.getElementById("pos");
        var coordinateObj = coordDOMNode.requestFieldRef("point");
        for (i=0; i<coordinateObj.length; i++) {
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
                