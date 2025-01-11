import pytest
from jsonschema import validate
from schemas.schemas import TOKEN_SCHEMA

valid_auth_data = [{"username": "admin", "password": "password123"}]

class TestAuthentication:
    @pytest.mark.parametrize("payload", valid_auth_data)
    def test_auth_token_valid(self, client, payload):
        response = client.create_token(payload)
        assert response.status_code == 200
        validate(instance=response.json(), schema=TOKEN_SCHEMA)
