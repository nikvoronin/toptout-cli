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

class EnvScope(object):
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
        'machine': 'EnvProperties',
        'user': 'EnvProperties',
        'process': 'EnvProperties'
    }

    attribute_map = {
        'machine': 'machine',
        'user': 'user',
        'process': 'process'
    }

    def __init__(self, machine=None, user=None, process=None):  # noqa: E501
        """EnvScope - a model defined in Swagger"""  # noqa: E501
        self._machine = None
        self._user = None
        self._process = None
        self.discriminator = None
        if machine is not None:
            self.machine = machine
        if user is not None:
            self.user = user
        if process is not None:
            self.process = process

    @property
    def machine(self):
        """Gets the machine of this EnvScope.  # noqa: E501


        :return: The machine of this EnvScope.  # noqa: E501
        :rtype: EnvProperties
        """
        return self._machine

    @machine.setter
    def machine(self, machine):
        """Sets the machine of this EnvScope.


        :param machine: The machine of this EnvScope.  # noqa: E501
        :type: EnvProperties
        """

        self._machine = machine

    @property
    def user(self):
        """Gets the user of this EnvScope.  # noqa: E501


        :return: The user of this EnvScope.  # noqa: E501
        :rtype: EnvProperties
        """
        return self._user

    @user.setter
    def user(self, user):
        """Sets the user of this EnvScope.


        :param user: The user of this EnvScope.  # noqa: E501
        :type: EnvProperties
        """

        self._user = user

    @property
    def process(self):
        """Gets the process of this EnvScope.  # noqa: E501


        :return: The process of this EnvScope.  # noqa: E501
        :rtype: EnvProperties
        """
        return self._process

    @process.setter
    def process(self, process):
        """Sets the process of this EnvScope.


        :param process: The process of this EnvScope.  # noqa: E501
        :type: EnvProperties
        """

        self._process = process

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
        if issubclass(EnvScope, dict):
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
        if not isinstance(other, EnvScope):
            return False

        return self.__dict__ == other.__dict__

    def __ne__(self, other):
        """Returns true if both objects are not equal"""
        return not self == other
