/* <script>
  
  document.querySelector("input[type='submit']").addEventListener("click", function(event)) {
    event.preventDefault();

    var name = document.querySelector("input[name='name']").value;
    var email = document.querySelector("input[name='email']").value;
    var message = document.querySelector("textarea[name='message']").value;

    if (!name) {
      alert("Please enter your name.");
      return;
    }
    if (!email) {
      alert("Please enter your email.");
      return;
    }
    if (!message) {
      alert("Please enter your message.");
      return;
    }

    alert("Your message has been sent successfully! Thank you, " + name + ".");
  }; */
  
  function shownav(){
    console.log("aaaaaaaaaaaaaa");
    let navBar = document.querySelector('#nav').classList;
    console.log(navBar)
    // let navBarList = document.querySelector('#list').classList;
    let navBarList = document.querySelector('#ton').classList;

    // navBar.toggle('show-navigation-panel');
    if(navBar.contains('navigation'))
    {
        navBar.remove('navigation');
        navBar.add('navigation-hidden');
        navBarList.add('control-hidden');
        navBarList.remove('control');

        
    }else {
      navBar.add('navigation');
      
      navBar.remove('navigation-hidden');
      navBarList.remove('control-hidden');
      navBarList.add('control');
    }
    
  }
