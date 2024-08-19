package Eccezioni;

import jdk.jshell.spi.ExecutionControl.RunException;

public class SessoNonValidoException extends RuntimeException {
	
	public SessoNonValidoException(String msg) {
		super(msg);
	}

}
