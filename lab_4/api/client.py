import requests

class RestfulBookerClient:
    BASE_URL = "https://restful-booker.herokuapp.com"

    def create_booking(self, payload):
        url = f"{self.BASE_URL}/booking"
        return requests.post(url, json=payload)

    def delete_booking(self, booking_id, token):
        url = f"{self.BASE_URL}/booking/{booking_id}"
        headers = {"Cookie": f"token={token}"}
        return requests.delete(url, headers=headers)

    def create_token(self, payload):
        url = f"{self.BASE_URL}/auth"
        return requests.post(url, json=payload)
