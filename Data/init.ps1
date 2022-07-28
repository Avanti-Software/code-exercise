$dataDir = [IO.Path]::Combine($PSScriptRoot, 'data');
if (Test-Path $dataDir) {
	Remove-Item $dataDir -Recurse -Force
}
New-Item $dataDir -ItemType 'Directory'
$clients = @('Acme', 'Contoso', 'Stark', 'Umbrella');
$seed = 1;
foreach ($client in $clients) {
	$clocks = @()
	$serialNo = 1000 * $seed;
	foreach ($increment in @(0..(Get-Random -Maximum 25))) {
		$serialNo += $increment;
		$clocks += @{
			SerialNo = $serialNo;
			Description = "Clock $serialNo";
			Active = $true;
			TimeZone = "EST";
		}
	}
	$clocks | ConvertTo-Json | Out-File ([IO.Path]::Combine($dataDir, "$client.json"));
	$seed += 1;
}