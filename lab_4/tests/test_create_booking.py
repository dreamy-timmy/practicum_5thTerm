import pytest
from jsonschema import validate
from schemas.schemas import CREATE_BOOKING_SCHEMA

valid_booking_data = [
    {
        "firstname": "John",
        "lastname": "Doe",
        "totalprice": 150,
        "depositpaid": True,
        "bookingdates": {
            "checkin": "2023-12-01",
            "checkout": "2023-12-10"
        },
        "additionalneeds": "Breakfast"
    }
]

class TestCreateBooking:
    @pytest.mark.parametrize("payload", valid_booking_data)
    def test_create_booking_valid(self, client, payload):
        response = client.create_booking(payload)
        assert response.status_code == 200
        validate(instance=response.json(), schema=CREATE_BOOKING_SCHEMA)
