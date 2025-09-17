package almata;

public class Usuari {
	private String nom;
	private String cognoms;
	private String correu;
	private String contrasenya;
	
	
	
	
	public Usuari(String nom, String cognoms, String correu, String contrasenya) {
		super();
		this.nom = nom;
		this.cognoms = cognoms;
		this.correu = correu;
		this.contrasenya = contrasenya;
	}
	
	
	public String getNom() {
		return nom;
	}
	public void setNom(String nom) {
		this.nom = nom;
	}
	public String getCognoms() {
		return cognoms;
	}
	public void setCognoms(String cognoms) {
		this.cognoms = cognoms;
	}
	public String getCorreu() {
		return correu;
	}
	public void setCorreu(String correu) {
		this.correu = correu;
	}
	public String getContrasenya() {
		return contrasenya;
	}
	public void setContrasenya(String contrasenya) {
		this.contrasenya = contrasenya;
	}


	@Override
	public String toString() {
		return "Usuari [nom=" + nom + ", cognoms=" + cognoms + ", correu=" + correu + ", contrasenya=" + contrasenya
				+ "]";
	}

	
	
}
