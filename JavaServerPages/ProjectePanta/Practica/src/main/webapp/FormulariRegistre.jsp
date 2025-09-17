<%@page import="java.util.Set"%>
<%@page import="java.util.LinkedHashSet"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
<%@ page import="almata.Usuari" %> 
<%@ page import="java.util.Set, java.util.LinkedHashSet" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style type="text/css">
	.error {
		padding: 2%;
		background-color: rgba(255, 0, 0, 0.4);
		border: 1px solid red;
	}
	
		.credencials-incorrectes {
		padding: 2%;
		background-color: red;
	}
</style>
</head>
<body>

	<%
		Usuari user = (Usuari) session.getAttribute("usuariLogejat");
		
		if(user != null){
			response.sendRedirect("Home.jsp");
		}
	%>

	<jsp:include page="ASSETS/Capçalera.jsp" />
	<form method="post">
		<label>Nom:</label>
		<input type="text" name="nom">
		<br>
		<label>Cognoms:</label>
		<input type="text" name="cognom">
		<br>
		<label>Correu electronic:</label>
		<input type="email" name="correu">
		<br>
		<label>Contrasenya:</label>
		<input type="password" name="password">
		<br>
		<input type="submit">
	</form>
	

	
	<%
	String nom = request.getParameter("nom");
	String cognom = request.getParameter("cognom");
	String mail = request.getParameter("correu");
	String contrasenya = request.getParameter("password");
	
	String text = "Error, No has inicialitzat les base de dades...";
	
	
	
	
	if(nom!=null){
		
		Set usuaris = (Set) application.getAttribute("llistaUsuaris");
		if (usuaris == null){
			
			%><p class="error"><%=text %><p>
			<jsp:include page="ASSETS/Footer.jsp" />
			<%
			return;
		}
		
		if(request.getParameter("nom").equals("") || request.getParameter("cognom").equals("") ||
				 request.getParameter("correu").equals("") || 
				 request.getParameter("password").equals("")){
			%><p class="credencials-incorrectes">No es pot ficar credencials buides</p>
			<jsp:include page="ASSETS/Footer.jsp" /><%
			return;
		}
		

		Usuari usuari = new Usuari(nom, cognom, mail, contrasenya);
		application.setAttribute("usuari", usuari);
		usuaris.add(usuari);
	}
	
	%>

	
	
	
		<jsp:include page="ASSETS/Footer.jsp" />


</body>
</html>


