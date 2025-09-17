<%@page import="java.util.Set"%>
<%@page import="almata.Usuari"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h1>Cookies</h1>
	
	<form method="post">
		<button type="submit" value="esborrar" name="button">Esborrar Cookies</button>
	</form>


	
	<%
	Cookie[] cookies = null;
	cookies = request.getCookies();
	
	String text = "esborrar";
	
	String boto = request.getParameter("button");
	
	if(cookies == null){
		out.print("No hi ha cookies");
		return;
	}
	
	if(boto != null && boto.equals(text)){
		for (Cookie a:cookies){
			if(!a.getName().equals("JSESSIONID")){
				a.setMaxAge(0);
				response.addCookie(a);
			}
		}
	} else {
		if (cookies != null) {
			out.println("Trobades galetes amb valors:");
			
			%> <br><br><br><br> <%
			
			for (int i = 0; i < cookies.length ; i++) {
				Cookie cuki = cookies[i];
				out.print("Nom: "+ cuki.getName() +".       Valor: "+ cuki.getValue());
				%> <br><br> <%
			}
		
		}
	}
	
	
	%>

	



</body>
</html>