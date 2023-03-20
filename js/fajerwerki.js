<script>
  
  document.querySelector("input[type='submit']").addEventListener("click", function(event) {
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
  });
</script>