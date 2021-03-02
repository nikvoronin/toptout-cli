# coding: utf-8

"""
    Toptout

    Get data about telemetry channels in various applications  # noqa: E501

    OpenAPI spec version: 0.0.1
    
    Generated by: https://github.com/swagger-api/swagger-codegen.git
"""

import pprint
import re  # noqa: F401

import six

class Links(object):
    """NOTE: This class is auto generated by the swagger code generator program.

    Do not edit the class manually.
    """
    """
    Attributes:
      swagger_types (dict): The key is attribute name
                            and the value is attribute type.
      attribute_map (dict): The key is attribute name
                            and the value is json key in definition.
    """
    swagger_types = {
        'main': 'str',
        'telemetry': 'str',
        'privacy': 'str'
    }

    attribute_map = {
        'main': 'main',
        'telemetry': 'telemetry',
        'privacy': 'privacy'
    }

    def __init__(self, main=None, telemetry=None, privacy=None):  # noqa: E501
        """Links - a model defined in Swagger"""  # noqa: E501
        self._main = None
        self._telemetry = None
        self._privacy = None
        self.discriminator = None
        self.main = main
        if telemetry is not None:
            self.telemetry = telemetry
        if privacy is not None:
            self.privacy = privacy

    @property
    def main(self):
        """Gets the main of this Links.  # noqa: E501


        :return: The main of this Links.  # noqa: E501
        :rtype: str
        """
        return self._main

    @main.setter
    def main(self, main):
        """Sets the main of this Links.


        :param main: The main of this Links.  # noqa: E501
        :type: str
        """
        if main is None:
            raise ValueError("Invalid value for `main`, must not be `None`")  # noqa: E501

        self._main = main

    @property
    def telemetry(self):
        """Gets the telemetry of this Links.  # noqa: E501


        :return: The telemetry of this Links.  # noqa: E501
        :rtype: str
        """
        return self._telemetry

    @telemetry.setter
    def telemetry(self, telemetry):
        """Sets the telemetry of this Links.


        :param telemetry: The telemetry of this Links.  # noqa: E501
        :type: str
        """

        self._telemetry = telemetry

    @property
    def privacy(self):
        """Gets the privacy of this Links.  # noqa: E501


        :return: The privacy of this Links.  # noqa: E501
        :rtype: str
        """
        return self._privacy

    @privacy.setter
    def privacy(self, privacy):
        """Sets the privacy of this Links.


        :param privacy: The privacy of this Links.  # noqa: E501
        :type: str
        """

        self._privacy = privacy

    def to_dict(self):
        """Returns the model properties as a dict"""
        result = {}

        for attr, _ in six.iteritems(self.swagger_types):
            value = getattr(self, attr)
            if isinstance(value, list):
                result[attr] = list(map(
                    lambda x: x.to_dict() if hasattr(x, "to_dict") else x,
                    value
                ))
            elif hasattr(value, "to_dict"):
                result[attr] = value.to_dict()
            elif isinstance(value, dict):
                result[attr] = dict(map(
                    lambda item: (item[0], item[1].to_dict())
                    if hasattr(item[1], "to_dict") else item,
                    value.items()
                ))
            else:
                result[attr] = value
        if issubclass(Links, dict):
            for key, value in self.items():
                result[key] = value

        return result

    def to_str(self):
        """Returns the string representation of the model"""
        return pprint.pformat(self.to_dict())

    def __repr__(self):
        """For `print` and `pprint`"""
        return self.to_str()

    def __eq__(self, other):
        """Returns true if both objects are equal"""
        if not isinstance(other, Links):
            return False

        return self.__dict__ == other.__dict__

    def __ne__(self, other):
        """Returns true if both objects are not equal"""
        return not self == other
