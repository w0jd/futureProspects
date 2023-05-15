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
    let navBar = document.querySelector('#nav').classList;
    let navBarList = document.querySelector('#list').classList;
    navBar.toggle('show-navigation-panel');
    if(navBar.contains('navigation-panel'))
    {
        navBar.remove('navigation-panel');
        navBar.add('navigation-panel-hidden');
        navBarList.add('hidden');
        
    }else {
      navBar.remove('navigation-panel-hidden');
      navBarList.remove('hidden');
      navBar.add('navigation-panel');
    }
    
  }
