# MultiTenantExample
Showcase for MultiTenantWebsite

1. Benötigt wird MSSQL DatenBank mit dbo.Tenant Tabelle:
 - Spalten: Id, Name, Host, Title, Theme

2. Trage Werte in die Tabelle ein:
- für Host Beispielhaft limitiert auf tenant1.site.com, tenant2.site.com
- für Theme limitiert auf tenant1.css, tenant2.css

3. in der Hostfile unter C:\Windows\System32\drivers\etc verweise mit den
URLs auf den localhost (füge am Ende 127.0.0.1	site.com
127.0.0.1	tenant1.site.com
127.0.0.1	tenant2.site.com hinzu.)

4. Öffne das Projekt im AdministratorModus

5. Füge die URLs der applicationshostconfigfile hinzu.

6. Ändere den connection String in der Web.config file

7. Teste das Projekt: Über tenant1.site.com und tenant2.site.com gelangt ma
zu den Nutzerspezifischen Seiten definiert über die Datenbank einträge


