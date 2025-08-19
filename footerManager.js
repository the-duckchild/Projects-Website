class SocialFooter extends HTMLElement {
    connectedCallback(){
        this.innerHTML = `<div class="flex justify-center items-center m-4 ">
    <footer id="footer-background"
      class="bottom-0 flex justify-center p-0 font-mono text-[#fe5f55] text-sm portait: w-[100%] landscape:w-[40%] z-52 rounded-xl"
    >

    <!-- Bluesky Logo-->
      <div
        class="w-full mx-auto max-w-screen-xl p-2 flex items-center justify-between"
      >
        <div class="flex w-[4vw] h-[4vh] min-w-[30px] justify-between p-[0.2vw] drop-shadow-xl/25 mr-10vw ml-20vw">
          <a href="https://bsky.app/profile/robotriddims.bsky.social">
            <img
              style="width: 100%; height: 100%"
              src="social/bluesky-blue-round-circle-logo-24461.svg"
              alt="Bluesky Logo"
            />
          </a>
        </div>

        <!-- FACEBOOK LOGO-->

        <div class="flex w-[4vw] h-[4vh] min-w-[30px] justify-between p-[0.2vw] drop-shadow-xl/25 mr-5vw ml-5vw">
          <a href="https://www.facebook.com/its.duck">
            <img
              style="width: 100%; height: 100%"
              src="https://upload.wikimedia.org/wikipedia/commons/b/b9/2023_Facebook_icon.svg"
              alt="Facebook Logo"
            />
          </a>
        </div>

        <!--BANDCAMP LOGO-->

        <div class="flex w-[4vw] h-[4vh] min-w-[30px] justify-between p-[0.2vw] drop-shadow-xl/25 mr-5vw ml-5vw">
          <a href="https://robotriddims.bandcamp.com/">
            <img
              style="width: 100%; height: 100%"
              src="https://upload.wikimedia.org/wikipedia/commons/6/6a/Bandcamp-button-bc-circle-aqua.svg"
              alt="Bandcamp Logo"
            />
          </a>
        </div>
        <!--    Instagram logo -->
        <div class="flex w-[4vw] h-[4vh] min-w-[30px] justify-between p-[0.2vw] drop-shadow-xl/25">
          <a href="https://www.instagram.com/robotriddims/">
            <img
              style="width: 100%; height: 100%"
              src="https://upload.wikimedia.org/wikipedia/commons/9/95/Instagram_logo_2022.svg"
              alt="Instagram Logo"
            />
          </a>
        </div>

        <!--    Spotify Logo   -->
        <div class="flex w-[4vw] h-[4vh] min-w-[30px] justify-between p-[0.2vw] drop-shadow-xl/25">
          <a
            href="https://open.spotify.com/artist/6jnqwrnUc0SLpT7wthJXmv?si=wTL_xnkBTAOs-rrVXYLg_A/&utm_source=copy-link"
          >
            <img
              style="width: 100%; height: 100%"
              src="https://upload.wikimedia.org/wikipedia/commons/1/19/Spotify_logo_without_text.svg"
              alt="Spotify Logo"
            />
          </a>
        </div>
    </div>
      </div>
    </footer>
  </div>`

    }
};

customElements.define('social-footer',SocialFooter);
