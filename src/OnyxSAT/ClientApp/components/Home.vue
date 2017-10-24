<template>
    <!-- <div class="home align-items-center container">
        <h1 class="display-3">ONYX</h1>
        <h2 class="">Attendence Tracker</h2>
        <h3>Swinburne University</h3>
        <h4>Developed by ONYX</h4>
    </div> -->
    

    <div id="HackyDiv">          
    </div>
    
</template>
<style scoped>


.home {
    text-align: center;
    font-family: Book Antique;
}


</style>

<script>
    export default {
        mounted() {
            class Timetable {
    
    constructor(left, top, width, height) {
        this.c = document.createElement('CANVAS');

        this.c.times = [];
        
        this.c.style.position = 'absolute';
        this.c.style.left = left;
        this.c.style.top = top;
        this.c.style.width = width+'px';
        this.c.style.height = height+'px';
        this.c.width = 700;
        this.c.height = 240;
        this.c.style.border = '1px solid black';

        let ctx = this.c.getContext('2d');
        this.c.daysInWeek = 7;
        this.c.hoursInDay = 12;

        this.c.dayIncrement = this.c.width/this.c.daysInWeek;
        this.c.hourIncrement = this.c.height/this.c.hoursInDay;
        
        for (let x = 0; x < this.c.daysInWeek; x++) {
            for (let y = 0; y < this.c.hoursInDay; y++) {
                ctx.strokeRect(x*this.c.dayIncrement,y*this.c.hourIncrement,this.c.dayIncrement,this.c.hourIncrement);
            }
        }

        this.c.draw = function() {
            this.dayIncrement = this.width/this.daysInWeek;
            this.hourIncrement = this.height/this.hoursInDay;
            
            let ctx = this.getContext('2d');			
        
            ctx.clearRect(0,0,this.width,this.height);
        
            ctx.fillStyle = "#000";
        
            for (let x = 0; x < this.daysInWeek; x++) {
                for (let y = 0; y < this.hoursInDay; y++) {
                    ctx.strokeRect(x*this.dayIncrement,y*this.hourIncrement,this.dayIncrement,this.hourIncrement);
                }
            }
        
            for (let i = 0; i < this.times.length; i++) {
                ctx.fillStyle = "#0F0";
                let day = this.times[i].day;
                let start = this.times[i].start;
                let length = this.times[i].length;
                let name = this.times[i].name;
                ctx.fillRect(day*this.dayIncrement,start*this.hourIncrement,this.dayIncrement,length*this.hourIncrement);
                ctx.strokeRect(day*this.dayIncrement,start*this.hourIncrement,this.dayIncrement,length*this.hourIncrement);
                
                ctx.fillStyle = "#000";
                let fontSize = this.hourIncrement*.75;
                ctx.font=fontSize+"px Georgia";
                ctx.fillText(name,day*this.dayIncrement,start*this.hourIncrement+fontSize);
            }
        }
        
        this.c.addSlot = function(day, start, length, name) {
            this.times.push({day, start, length, name});
            this.draw();
        }
        
        this.c.remove = function(name) {
            for (let i = 0; i < this.times.length; i++) {
                if (this.times[i].name == name) {
                    this.times.splice(i,1);
                    this.draw();
                    return;
                }
            }
        }

        return this.c;
    }

}

function hackyWaitRun() {
    console.log("HRW");
    let i = new Timetable(0,0,700,240);			

    document.getElementById("HackyDiv").appendChild(i);
    i.addSlot(0,1,4,"Potato Studies");
    i.addSlot(1,3,5,"Potato Sculpting");
}

hackyWaitRun();            
        }
    } 
</script>