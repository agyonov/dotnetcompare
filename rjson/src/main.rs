mod jdata;

use crate::jdata::JData;
use std::{fs::OpenOptions, io::Read, path::PathBuf};
use stopwatch::Stopwatch;

fn main() {
    // Define the name of the source file
    const FILE_NAME: &str = "large-file.json";

    // Open file
    let file_path = PathBuf::from(FILE_NAME);
    let mut file = match OpenOptions::new().read(true).open(file_path) {
        Ok(file) => file,
        Err(err) => {
            println!(
                "Can not open file - {}. Err: {}",
                FILE_NAME,
                err.to_string()
            );
            return;
        }
    };

    // Read file
    let mut contents: String = "".to_string();
    match file.read_to_string(&mut contents) {
        Ok(size) => println!("Read {} bytes", size),
        Err(err) => {
            println!(
                "Can not read file - {}. Err: {}",
                FILE_NAME,
                err.to_string()
            );
            return;
        }
    }

    for idx in 0..50 {
        //Start
        let mut sw = Stopwatch::start_new();
        // Parse JSON
        let jdata: Vec<JData> = match serde_json::from_str(contents.as_str()) {
            Ok(parsed) => parsed,
            Err(err) => {
                println!("Can not parse JSON data. Err: {}", err.to_string());
                return;
            }
        };
        // Stop
        sw.stop();

        // Show result
        println!(
            "Run [{}]. Deserialized\t{} records. In {} ms.",
            idx,
            jdata.len(),
            sw.elapsed_ms()
        );

        // Start
        sw.restart();
        // Serialize
        let serialized: String = match serde_json::to_string(&jdata) {
            Ok(res) => res,
            Err(err) => {
                println!("Can not serialize JSON data. Err: {}", err.to_string());
                return;
            }
        };
        // Stop
        sw.stop();

        // Print final result
        println!(
            "Run [{}]. Seriliazed\t{} bytes. In {} ms.",
            idx,
            serialized.len(),
            sw.elapsed_ms()
        );
    }
}
