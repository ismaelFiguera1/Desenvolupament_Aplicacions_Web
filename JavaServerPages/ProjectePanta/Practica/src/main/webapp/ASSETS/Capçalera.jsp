<%@page import="almata.Usuari"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<style>
	header {
		border: 1px solid #ff7a7a;
		padding: 3%;
		background-color: #ff7a7a;
		margin-bottom: 2%;
	}
	
	.capçalera {
		display: grid;
		grid-template-columns: 1fr 1fr;
		font-size: 32px;
	}
	
	.capçalera * {
		text-decoration: none;
		color: black;
	
	}
	
	
</style>
    
    
    <header>
    	<section class="capçalera">
    		<div><a href="Home.jsp">ARMASA</a></div>
    		
    		<%
    			Usuari user = (Usuari) session.getAttribute("usuariLogejat");
    			if(user == null){
    				%><div>
    				
    				<a href="Login.jsp">Login</a>
    				<a href="FormulariRegistre.jsp">Registrar-se</a>
    				
    				</div><%
    			} else {
    				
    				%><div>
    				 	<ul>
    				 		<li><%out.print(user.getNom());%></li>
    				 		<li><%out.print(user.getCognoms());%></li>
    				 	</ul>
    				</div><%
    			}
    		%>
    		
    	</section>
    
    </header>