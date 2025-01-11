import pytest
import sys
import os

sys.path.append(os.path.dirname(os.path.abspath(__file__)) + "/../")

from api.client import RestfulBookerClient

@pytest.fixture
def client():
    return RestfulBookerClient()
