<?php 
main();
function main () {
	
    echo '<a href="https://github.com/badluckbert/code/blob/main/php/CovidApi.php">GithubCode</a>';
	$apiCall = 'https://api.covid19api.com/summary';
	$json_string = file_get_contents($apiCall); 
	$json_string = curl_get_contents($apiCall);
	$data = json_decode($json_string);
	$countries = Array();
	foreach($data->Countries as $i){
		$country = array(
			"Country" => $i->Country,
			"TotalDeaths" => $i->TotalDeaths);
		array_push($countries, $country);
	}

	$deaths= array_column($data->Countries, "TotalDeaths");
	array_multisort($deaths, SORT_DESC, $countries);
	$countries=array_slice($countries, 0, 10);
	$topten=json_decode(json_encode($countries));
	echo '<h1>Top Ten Countries</h1>
	<table style="border: 1px solid black;">
		<tr>
			<th>Country</th>
			<th>Death</th>
		</tr>';
	foreach($topten as $i){
		echo '<tr>
			<td>' . $i->Country . '</td>
			<td>' . $i->TotalDeaths . '</td>
		</tr>';
	}
	echo '</table>';
}
// read data from a URL into a string
function curl_get_contents($url) {
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($ch, CURLOPT_HEADER, 0);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_URL, $url);
    $data = curl_exec($ch);
    curl_close($ch);
    return $data;
}
?>
