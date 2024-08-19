package GestioneReferti;

import java.util.ArrayList;
import java.util.Collections;
import Classi.Paziente;
import Classi.Referto;
import Classi.RefertoImmagine;
import Classi.RefertoMultiplo;
import Classi.RefertoSingolo;
import Classi.RisultatoReferto;

public class GestioneReferti {
	
	ArrayList<Referto> listaReferti;
	ArrayList<Paziente> listaPaziente;
	
	public GestioneReferti() {
		this.listaReferti = new ArrayList<Referto>();
		this.listaPaziente = new ArrayList<Paziente>();
	}
	
	public void inserisciRefertoSingolo(String data, Paziente paziente, String nome, RisultatoReferto risultato) {
		RefertoSingolo referto = new RefertoSingolo(data, paziente, nome, risultato);
		paziente.listaRefertiPersonale.add(referto);
		this.listaReferti.add(referto);
		for(Paziente pa: this.listaPaziente) {
			if(pa.ID.equals(paziente.ID)) {
				return;
			}
		}
		this.listaPaziente.add(paziente);
	}
	
	public void inserisciRefertoMultiplo(String data, Paziente paziente) {
		RefertoMultiplo referto = new RefertoMultiplo(data, paziente);
		paziente.listaRefertiPersonale.add(referto);
		this.listaReferti.add(referto);
		for(Paziente pa: this.listaPaziente) {
			if(pa.ID.equals(paziente.ID)) {
				return;
			}
		}
		this.listaPaziente.add(paziente);
	}
	
	public void inserisciRefertoImmagine(String data, Paziente paziente, String nomeFile, String testo, String dottore) {
		RefertoImmagine referto = new RefertoImmagine(data, paziente, nomeFile, testo, dottore);
		paziente.listaRefertiPersonale.add(referto);
		this.listaReferti.add(referto);
		for(Paziente pa: this.listaPaziente) {
			if(pa.ID.equals(paziente.ID)) {
				return;
			}
		}
		this.listaPaziente.add(paziente);
	}
	
	public void eliminaRefertiPazienteID(String IDpaziente) {
		int count = 0;
		for(Referto r: this.listaReferti) {
			if(r.paziente.ID.equals(IDpaziente)) {
				r.paziente.listaRefertiPersonale = new ArrayList<Referto>();
				this.listaReferti.remove(r);
				count++;
			}
		}
		System.out.println("Eliminati " + count + " referti.");
	}
	
	public void eliminaRefertiPaziente(String nome, String cognome) {
		int count = 1;
		for(int r=0; r<this.listaReferti.size(); r++) {
			if(this.listaReferti.get(r).paziente.nome.equalsIgnoreCase(nome) && this.listaReferti.get(r).paziente.cognome.equalsIgnoreCase(cognome)) {
				this.listaReferti.get(r).paziente.listaRefertiPersonale = new ArrayList<Referto>();
				this.listaReferti.remove(r);
				count++;
			}
		}
		System.out.println("Eliminati " + count + " referti.");
	}	
	
	public static ArrayList<Referto> copiaArrayValidi(ArrayList<Referto> lista) {
		ArrayList<Referto> referti = new ArrayList<Referto>();
		for(Referto r: lista) {
			if(r.validity())
				referti.add(r);
		}
		return referti;
	}
	
	public static ArrayList<Referto> sortCriticity(ArrayList<Referto> lista) {
		ArrayList<Referto> lista2 = copiaArrayValidi(lista);
		boolean ordinato = false;
		do {
			ordinato = true;
			for(int i=0; i<lista2.size()-1; i++) {
				if(lista2.get(i).criticity() > lista2.get(i+1).criticity()) {
					Collections.swap(lista2, i, i+1);
					ordinato = false;
				}
			}
		}while(!ordinato);
		return lista2;
	}
	
	public void stampaRefertiPerCriticità() {
		ArrayList<Referto> lista = sortCriticity(this.listaReferti);
		for(Referto r: lista) {
			System.out.println(r);
		}
	}
	
	public void stampaRefertiPerData() {
		Collections.sort(this.listaReferti);
		for(Referto r: this.listaReferti) {
			if(r.validity())
				System.out.println(r);
		}
	}
	
	public void stampaRefertiPerPaziente() {
		for(Paziente p: this.listaPaziente) {
			System.out.println(p);
			for(Referto r : p.listaRefertiPersonale) {
				System.out.println(r);			
			}
			System.out.println();
		}
	}
	
	//utilizzo di Jautodoc per commentare i metodi, da implementare su tutti
	
	/**
	 * Stampa istogramma.
	 *
	 * @param min valore
	 * @param max valore
	 * @param step valore
	 */
	public void stampaIstogramma(int min, int max, int step) {
		if(min > max || min > step || step > max) {
			System.out.println("Errore: dati non validi.");
			return;
		}
		System.out.print(min + "\t\t|");
		for(Referto r: this.listaReferti) {
			if(r.criticity() == min)
				System.out.print("*");
		}
		System.out.println();
		
			for(int i=min+step; i<max; i+=step) {
				System.out.print(i + "\t\t|");
				for(Referto r: this.listaReferti) {
					if(r.criticity() == i)
						System.out.print("*");
				}
				System.out.println();
			}
		System.out.print(max + "\t\t|");
		for(Referto r: this.listaReferti) {
			if(r.criticity() == max)
				System.out.print("*");
		}
	}
	
	public void addEsameRefMultiplo(String IDreferto, String nome, float valore) {
		ArrayList<RefertoMultiplo> refertiMultipli = new ArrayList<RefertoMultiplo>();
		for(Referto i: this.listaReferti) {
			if(i instanceof RefertoMultiplo) {
				refertiMultipli.add((RefertoMultiplo) i);
			}
		}
		
		for(RefertoMultiplo r: refertiMultipli) {
			if(r.ID.equals(IDreferto)) {
				((RefertoMultiplo)r).AddEsame(nome, valore);
				return;
			}
		}
	}
	
	
	
	public static void main(String[] args) {
		
		GestioneReferti gestore = new GestioneReferti();
		
		//creo alcuni pazienti
		Paziente p1 = new Paziente("Stefano", "Masserini" , "03.03.1993", "maschio");
		Paziente p2 = new Paziente("Greta", "Servalli" , "03.03.1993", "femmina");
		Paziente p3 = new Paziente("Alberto", "Servalli" , "03.03.1993", "maschio");
		
		//provo a inserire referti
		gestore.inserisciRefertoSingolo("12.07.2020", p1, "Test_Covid-19", RisultatoReferto.NEGATIVO);
		gestore.inserisciRefertoSingolo("12.07.2020", p1, "Test_Covid-19", RisultatoReferto.DUBBIO);
		gestore.inserisciRefertoMultiplo("12.07.2020", p2);
		gestore.inserisciRefertoImmagine("12.08.2020", p2, "RaggiX_gamba_dx", "Riportate lesioni alle ossa, CRITICO", "Dottor Stumpo");
		gestore.inserisciRefertoSingolo("12.07.2020", p3, "Test_Covid-19", RisultatoReferto.NEGATIVO);
		gestore.inserisciRefertoSingolo("24.06.2020", p3, "Test_Covid-19", RisultatoReferto.DUBBIO);
		gestore.inserisciRefertoSingolo("12.07.2020", p3, "Test_Covid-19", RisultatoReferto.NEGATIVO);
		gestore.inserisciRefertoSingolo("12.07.2020", p3, "Test_Covid-19", RisultatoReferto.POSITIVO);
		gestore.inserisciRefertoImmagine("24.06.2020", p2, "RaggiX_gamba_dx", "Riportate lesioni alle ossa, CRITICO", "Dottor Stumpo");
		gestore.inserisciRefertoImmagine("24.06.2020", p2, "RaggiX_gamba_dx", "Riportate lesioni alle ossa, CRITICO", "Dottor Stumpo");
		//prova senza critico nel testo
		gestore.inserisciRefertoImmagine("24.06.2020", p2, "RaggiX_gamba_dx", "Riportate lesioni alle ossa, non grave", "Dottor Stumpo");
		
		//aggiungo un esame ad un referto multiplo
		gestore.addEsameRefMultiplo("000002", "emoglobina", 7);
		gestore.addEsameRefMultiplo("000002", "globuli bianchi", 3);
		
		//prova delle stampe
		gestore.stampaRefertiPerCriticità();
		System.out.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		gestore.stampaRefertiPerData();
		System.out.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		gestore.stampaRefertiPerPaziente();
		System.err.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		
		//prova istogramma a volte crea degli spazi strani ma ricliccando RUN spariscono
		gestore.stampaIstogramma(0, 10, 1);
		System.out.println();
		System.out.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		
		//prova istogramma step diverso
		gestore.stampaIstogramma(0, 10, 2);
		System.out.println();
		System.out.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		
		//provo ad eliminare tutti i referti di un paziente
		gestore.eliminaRefertiPaziente("Alberto", "Servalli");
		gestore.stampaRefertiPerPaziente();
		System.err.println();
		System.out.println("*************************************************************************************************************************************************************");
		System.out.println();
		
		//provo ancora
		gestore.eliminaRefertiPaziente("Greta", "Servalli");
		gestore.stampaRefertiPerPaziente();
	}

}





























