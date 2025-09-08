class Navbar extends HTMLElement {
    connectedCallback(){
        this.innerHTML = `
        <script>navbarContextHighlight.js</script>
            <header
      class="hidden landscape:flex justify-center text-center sticky top-0 z-51"
    >
      <nav
        class="fixed flex font-mono justify-center align-center bg-linear-to-r from-[#086375] to-[#78c3fb] text-[#ffffff] drop-shadow-xl/25 text-[calc(1vh+1vw*0.50)] lg:text-[calc(1vh+1vw*0.8)] xl:text-lg m-[5vh] w-90% md:w-[60%] rounded-[25px] md:rounded-[50px] overflow-hidden"
      >
        <ul
          class="flex flex-row text-center p-0 overflow-hidden list-none m-[8px] text-base xl:text-xl"
        >
          <li
            class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw] text-center"
          >
            <a href="index.html" class="block p=[0.1em] hover:text-[#086375]"
              >Home</a
            >
          </li>
          <li class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw] text-[#FFFF00]">
            <a
              href="electronics.html"
              class="block p=[0.1em] hover:text-[#086375]"
              >Electronics</a
            >
          </li>
          <li
            class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw] "
          >
            <a href="soundart.html" class="block p=[0.1em] hover:text-[#086375]"
              >Sound Art</a
            >
          </li>
          <li class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="robotriddims.html"
              class="block p=[0.1em] hover:text-[#086375]"
              >Robot Riddims</a
            >
          </li>

          <li class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="bambamsound.html"
              class="block p=[0.1em] text-center hover:text-[#086375] "
              >Bam Bam Sound</a
            >
          </li>
          <li class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="contactform.html"
              class="block p=[0.1em] text-center hover:text-[#086375]"
              >Contact</a
            >
          </li>
        </ul>
      </nav>
    </header>
       
    <!--Navigation for portrait screens in the form of a hamburger drop down menu. Simple animation from CSS styles-->


    <label class="hamburger-menu hidden portrait:flex portrait:flex-col items-center drop-shadow-md">
      <input type="checkbox">
    </label>
      <aside class="sidebar bg-[rgba(244,116,59,0.6)] landscape:hidden">
        <nav class="font-mono text-center font-size-[3em]">
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="index.html">Home</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 text-[#FFFF00]"><a href="electronics.html">Electronics</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="soundart.html">Sound Art</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5"><a href="robotriddims.html">Robot Riddims</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5"><a href="bambamsound.html">Bam Bam Sound</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5"><a href="contactform.html">Contact</a></div>
        </nav>


      </aside>

<div class="hidden landscape:block top-0 min-w-6000 fixed h-[9vh] bg-[#F2EDE1] z-50 "></div>`
    }
};

customElements.define('nav-bar',Navbar);