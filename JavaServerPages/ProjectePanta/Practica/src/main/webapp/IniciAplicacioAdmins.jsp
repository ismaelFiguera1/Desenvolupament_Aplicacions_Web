<%@page import="java.util.LinkedHashSet"%>
<%@page import="almata.Usuari"%>
<%@page import="java.util.Set"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

<h1>Inici Aplicacio Administradors</h1>



	<p>Iniciant base de dades...</p>
		<%
		Set usuaris = new LinkedHashSet();
		application.setAttribute("llistaUsuaris", usuaris);
		%>
</body>
</html>