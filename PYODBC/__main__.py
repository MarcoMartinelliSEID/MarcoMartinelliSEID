import pyodbc 
# Some other example server values are
# server = 'localhost\sqlexpress' # for a named instance
# server = 'myserver,port' # to specify an alternate port
server = 'fileserver2.seid.lan' 
database = 'sbo_seid' 
username = 'sa' 
password = 'B1Admin' 
cnxn = pyodbc.connect('DRIVER={SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
cursor = cnxn.cursor()

#Sample select query
cursor.execute("SELECT project_key, project_number, sproject_number FROM trimergo.planning WHERE (((type_name)='Project' Or (type_name)='SubProj'))") 
row = cursor.fetchone() 
while row: 
    print(str(row[0]) + '\t\t\t' + str(row[1]) + '\t\t\t' + str(row[2]))
    row = cursor.fetchone()

'''
for row in cursor.fetchall():
    print row
'''