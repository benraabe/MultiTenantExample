# MultiTenantExample
Showcase for MultiTenantWebsite

1. Ben�tigt wird MSSQL DatenBank mit dbo.Tenant Tabelle:
 - Spalten: Id, Name, Host, Title, Theme

2. Trage Werte in die Tabelle ein:
- f�r Host Beispielhaft limitiert auf tenant1.site.com, tenant2.site.com
- f�r Theme limitiert auf tenant1.css, tenant2.css

3. in der Hostfile unter C:\Windows\System32\drivers\etc verweise mit den
URLs auf den localhost (f�ge am Ende 127.0.0.1	site.com
127.0.0.1	tenant1.site.com
127.0.0.1	tenant2.site.com hinzu.)

4. �ffne das Projekt im AdministratorModus

5. F�ge die URLs der applicationshostconfigfile hinzu.

6. �ndere den connection String in der Web.config file

7. Teste das Projekt: �ber tenant1.site.com und tenant2.site.com gelangt ma
zu den Nutzerspezifischen Seiten definiert �ber die Datenbank eintr�ge


