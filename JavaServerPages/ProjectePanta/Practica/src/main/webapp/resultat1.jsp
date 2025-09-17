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
	<h1>Usuari logejat en aquesta sessio</h1>
	<%
	
	// Tinc que fer el cast a Usuari, perque el setAtribute em guarda un objecte i aqui vull rebre l'usuari
	
	Usuari user = (Usuari) session.getAttribute("usuariLogejat");
	
	if(user==null){
		%><p>No hi ha cap usuari a la sessio</p><%
	} else {
		out.print(user.toString());
	}
	%>

</body>
</html>