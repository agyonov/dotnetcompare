use std::collections::HashMap;
use serde_json::Value;
use serde::{Serialize, Deserialize};
use time::OffsetDateTime;

#[derive(Serialize, Deserialize, Debug)]
pub struct Actor{
    pub id: usize,

    pub login: String,

    pub gravatar_id: String,

    pub url: String,

    pub avatar_url: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Repo{
    pub id: usize,

    pub name: String,

    pub url: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct JData {

    pub id: String,

    pub r#type: String,

    pub actor: Actor,

    pub repo: Repo,

    pub payload: HashMap<String, Value>,

    pub public: bool,

    #[serde(with = "time::serde::iso8601")]
    pub created_at: OffsetDateTime,
}
