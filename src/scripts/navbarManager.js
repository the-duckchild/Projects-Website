class Navbar extends HTMLElement {
  connectedCallback() {
    this.innerHTML = `
        <script>navbarContextHighlight.js</script>
        <body>
            <header
      class="hidden landscape:flex justify-center text-center sticky top-0 z-51 "
    >
      <nav id="navBar"
        class="fixed flex font-mono justify-center align-center bg-linear-to-r from-[#086375] to-[#78c3fb] text-[#ffffff] drop-shadow-md  m-[5vh] w-90% md:w-[60%] rounded-[25px] md:rounded-[50px] overflow-hidden"
      >
        <ul
          class="flex flex-row text-center p-0 overflow-hidden list-none m-[8px] text-sm lg:text-base xl:text-xl"
        >
          <li id="homeLink"
            class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw] text-center"
          >
            <a href="/" class="text-white navBarElement block p=[0.1em] hover:text-[#086375]"
              >Home</a
            >
          </li>
          <li id="electronicsLink" class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="/electronics.html"
              class="navBarElement block p=[0.1em] hover:text-[#086375]"
              >Electronics</a
            >
          </li>
          <li 
            class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw] "
          >
            <a href="/soundart.html" id="SoundArtLink" class="navBarElement block p=[0.1em] hover:text-[#086375]"
              >Sound Art</a
            >
          </li>
          <li  class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a 
              href="/robotriddims.html"
              id="RobotRiddimsLink"
              class="navBarElement block p=[0.1em] hover:text-[#086375]"
              >Robot Riddims</a
            >
          </li>

          <li class=" rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="/bambamsound.html"
              id="bamBamSoundLink"
              class="navBarElement block p=[0.1em] text-center hover:text-[#086375] "
              >Bam Bam Sound</a
            >
          </li>
          <li class="rounded-[50px] hover:bg-[rgba(244,116,59,0.6)] p-[0.5vw]">
            <a
              href="contactform.html"
              id="contactLink"
              class="navBarElement block p=[0.1em] text-center hover:text-[#086375]"
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
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="index.html" class="navBarElement">Home</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="electronics.html" class="navBarElement">Electronics</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="soundart.html" class="navBarElement">Sound Art</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="robotriddims.html" class="navBarElement">Robot Riddims</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="bambamsound.html" class="navBarElement">Bam Bam Sound</a></div>
          <div class ="p=[0.5em] font-bold text-center m-5 "><a href="contactform.html" class="navBarElement">Contact</a></div>
        </nav>


      </aside>

<div class="block top-0 w-[100%] fixed h-[9vh] bg-[#F2EDE1] z-50 "></div>`;
  }
}

customElements.define("nav-bar", Navbar);
