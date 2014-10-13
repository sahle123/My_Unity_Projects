#pragma strict

public var AA_quality : int = 2;
function Start () {
	QualitySettings.antiAliasing = AA_quality;
}