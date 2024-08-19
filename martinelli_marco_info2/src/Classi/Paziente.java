package Classi;

import java.text.DecimalFormat;
import java.util.ArrayList;

import Eccezioni.IDgi‡EsistenteException;
import Eccezioni.SessoNonValidoException;
import prog.utili.Data;

public class Paziente {
	
	public String ID;
	public String nome;
	public String cognome;
	Data dataNascita;
	String sesso;
	public ArrayList<Referto> listaRefertiPersonale;
	
	private static int IDs = 0;
	private static ArrayList<String> listaIDpaziente = new ArrayList<String>();
	
	public Paziente(String nome, String cognome, String dataNascita, String sesso) {
		this.nome = nome;
		this.cognome = cognome;
		this.dataNascita = new Data(dataNascita);
		this.sesso = sesso;
		if(!(sesso.equalsIgnoreCase("maschio") || sesso.equalsIgnoreCase("femmina")))
			throw new SessoNonValidoException("Errore: Il sesso della persona Ë da indicare maschi o femmina");
		this.listaRefertiPersonale = new ArrayList<Referto>();
		this.ID = generaID(nome, cognome);
		listaIDpaziente.add(this.ID);
	}
	
	public Paziente(String ID, String nome, String cognome, String dataNascita, String sesso) {
		this.nome = nome;
		this.cognome = cognome;
		this.dataNascita = new Data(dataNascita);
		this.sesso = sesso;		
		try {
			controlloID(ID);
			this.ID = ID;
			listaIDpaziente.add(this.ID);
		} catch (IDgi‡EsistenteException e) {
			System.out.println("Errore: ID gi‡ utilizzato.");
		}		
	}	

	private void controlloID(String ID) throws IDgi‡EsistenteException {
		for(String s: listaIDpaziente) {
			if(s.equals(ID))
				throw new IDgi‡EsistenteException();
		}		
	}

	private String generaID(String nome, String cognome) {
		DecimalFormat df = new DecimalFormat("0000");
		String s = cognome.substring(0, 3) + nome.substring(0, 3) + df.format(IDs++);
		try {
			controlloID(s);
		} catch (IDgi‡EsistenteException e) {
			s = cognome.substring(0, 3) + nome.substring(0, 3) + df.format(IDs++);
		}
		return s;
	}
	
	@Override
	public String toString() {
		return "Paziente: " + this.nome + " " + this.cognome + " - ID: " + this.ID;
	}

}
