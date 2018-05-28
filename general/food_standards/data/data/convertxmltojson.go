package main

import (
	"encoding/json"
	"encoding/xml"
	"fmt"
	"io/ioutil"
	"os"
)

type FHRSEstablishment struct {
	EstablishmentCollection EstablishmentCollection `xml:"EstablishmentCollection" json:"data"`
}

type EstablishmentCollection struct {
	Establishments []EstablishmentDetail `xml:"EstablishmentDetail" json:"establishments"`
}

type EstablishmentDetail struct {
	BusinessName string `json:"name"`
	AddressLine1 string `json:"address1"`
	AddressLine2 string `json:"address2"`
	AddressLine3 string `json:"address3"`
	PostCode     string `json:"postcode"`
	RatingValue  string `json:"rating"`
}

func main() {
	f, err := os.Open("FHRS413en-GB.xml")
	if err != nil {
		fmt.Println("Failed to open the XML input file.", err)
		os.Exit(-1)
	}
	defer f.Close()
	data, err := ioutil.ReadAll(f)
	if err != nil {
		fmt.Println("Failed to read the XML input file.", err)
		os.Exit(-1)
	}
	d := FHRSEstablishment{}
	err = xml.Unmarshal(data, &d)
	if err != nil {
		fmt.Println("Failed to unmarshal XML input file.", err)
		os.Exit(-1)
	}

	// Convert to JSON, because no-one truly loves XML.
	e := json.NewEncoder(os.Stdout)
	e.SetIndent("", "  ")
	err = e.Encode(d)
	if err != nil {
		fmt.Println("Failed to convert struct to JSON.", err)
		os.Exit(-1)
	}
}
