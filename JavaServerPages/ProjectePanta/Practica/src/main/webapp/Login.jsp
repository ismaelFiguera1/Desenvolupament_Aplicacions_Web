<%@page import="almata.Usuari"%>
<%@page import="java.util.Set"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<style type="text/css">
	.baix {
		display: flex;
		gap: 20px;
	}
	
	.credencials-incorrectes {
		padding: 2%;
		background-color: rgba(255, 0, 0, 0.4);
		border: 1px solid red;
	}

</style>
</head>
<body>
<%
	Usuari user = (Usuari) session.getAttribute("usuariLogejat");

	Cookie[] cookiesNavegador = null; 
	cookiesNavegador=request.getCookies();
	
	Cookie a=null;
	
	for(Cookie b:cookiesNavegador){
		if(b.getName().equals("email")){
			a=b;
		}
	}
/*	
	if(a!=null){
		response.sendRedirect("PaginaPrivada.jsp");
	}
*/
%>
<jsp:include page="ASSETS/Capçalera.jsp" />
	<h1>Login</h1>
	
	<section>
	<form method="post">
		<article>
			<label>Correu ectronic</label>
			<input type="email" name="correu">
		</article>
		<article>
			<label>Contrasenya</label>
			<input type="password" name="contrasenya">
		</article>
		<article class="baix">
			<article>
				<input type="checkbox"  name="check">			
				<label>Recordar-me</label>
			</article>
			<button type="submit">
				Entrar
			</button>
		</article>
	</form>
	</section>
	
	<%
	if(request.getParameter("correu")!=null){
		
		if(request.getParameter("correu").equals("") || 
				request.getParameter("contrasenya").equals("")){
			%><p class="credencials-incorrectes">No es pot ficar credencials buides</p>
			<jsp:include page="ASSETS/Footer.jsp" /><%
			return;
		}
		
	String correu = request.getParameter("correu");
	String contrasenya = request.getParameter("contrasenya");
	String text = "";
	String	seleccionat = request.getParameter("check");
	

	
	

		
		
		
		
		if(!(seleccionat==null)){
			Cookie cookie = new Cookie("email", request.getParameter("correu"));
			cookie.setMaxAge(60*60*24);
			response.addCookie(cookie);
			
			Cookie cookie1 = new Cookie("contrasenya", request.getParameter("contrasenya"));
			cookie.setMaxAge(60*60*24);
			response.addCookie(cookie1);
		}
		
		
		
		
		
		
		Set usuaris = (Set) application.getAttribute("llistaUsuaris");
		
	
		boolean trobat = false;
		
		for (Object obj: usuaris){
			Usuari usuari = (Usuari) obj;
			String mail = usuari.getCorreu();
			String password = usuari.getContrasenya();
			if(mail.equals(correu) && password.equals(contrasenya)){
				session.setAttribute("usuariLogejat", usuari);
				response.sendRedirect("Home.jsp");
			}
			
		}
		
		if(trobat==false){
			text = "Credencials incorrectes"; 
			%><p class="credencials-incorrectes"><%=text %></p><%
		}
	}
	%>
	
	
	
	<jsp:include page="ASSETS/Footer.jsp" />
</body>
</html>