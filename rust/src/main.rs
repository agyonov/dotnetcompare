use rand::{thread_rng, Rng};
use stopwatch::Stopwatch;

fn main() {
    let mut rng = thread_rng();
    let mut a_src = vec![0u8; 268435456]; // 268Mb

    for item in &mut a_src {
        *item = rng.gen();
    }

    let mut all:u64 = 0;
    let mut i_loop = 0;
    while i_loop < 21 {
        let mut d: f64 = 0.0;
        let mut a: u32;
        let sw = Stopwatch::start_new();
        for item in &a_src {
            a = (*item as u32) * 2;
            d = d + (a as f64) / 313.0f64;
        }

        let hlp = sw.elapsed_ms();
        all = all + hlp as u64;
        println!("[{i_loop}] - Time: {} ms. {d}", hlp);
        i_loop = i_loop + 1;
    }
    println!("AvgTime: {} ms.", all / 21);
}
