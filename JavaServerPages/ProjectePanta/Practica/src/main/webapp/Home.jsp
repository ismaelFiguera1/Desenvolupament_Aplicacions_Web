<%@page import="java.util.Set"%>
<%@page import="almata.Usuari"%>
<%@page import="java.util.LinkedHashSet"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<link rel="stylesheet" type="text/css" href="STYLES/Home.css">
</head>
<body>
	<header>
		<h1>ARMASA</h1>
	</header>
	<section>
		<article>
			<img alt="" src="ASSETS/narangito.jpg">
		</article>
		<article class="descripcio">
			<p>Amazon.com, Inc. es una corporación estadounidense 
			de comercio electrónico y servicios de computación en 
			la nube a todos los niveles con sede en la ciudad de 
			Seattle, Washington.1​ Su lema es: From A to Z 
			(traducido al español: «De la A a la Z»). Es una de 
			las primeras grandes compañías en vender bienes a través 
			de Internet. Amazon también posee Alexa Internet, a9.com, 
			Shop bop, Internet Movie Database (IMDb), MGM Holdings, 
			Zappos.com, DPreview.com y Twitch. 
			Es la marca de venta al por menor más valiosa del 
			mundo según el índice BrandZ.2</p>
		</article>
		<article class="enllaços">
			<a href="PaginaPrivada.jsp">Pagina Privada</a>
			<a href="PaginaDades.jsp">Pagina Dades</a>
		</article>
	</section>
	<jsp:include page="ASSETS/Footer.jsp" />
	
	
	<%
		Cookie[] cuky=null;
	cuky = request.getCookies();
	
	if(cuky!=null){
		for(Cookie a:cuky){
			if(a.getName().equals("email")){
				Set llistaUser = (Set) application.getAttribute("llistaUsuaris");
				for(Object obj:llistaUser){
					Usuari usuari = (Usuari) obj;
					if(usuari.getCorreu().equals(a.getValue())){
						session.setAttribute("usuariLogejat", usuari);
						return;
					}
				}
			}
		}
	}
	%>
</body>
</html>