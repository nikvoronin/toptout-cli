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

class Target(object):
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
        '_exec': 'ModelExec',
        'env': 'Env',
        'plain_file': 'PlainFile',
        'json_file': 'JSONFile',
        'registry': 'Registry',
        'noop': 'list[Noop]'
    }

    attribute_map = {
        '_exec': 'exec',
        'env': 'env',
        'plain_file': 'plain_file',
        'json_file': 'json_file',
        'registry': 'registry',
        'noop': 'noop'
    }

    def __init__(self, _exec=None, env=None, plain_file=None, json_file=None, registry=None, noop=None):  # noqa: E501
        """Target - a model defined in Swagger"""  # noqa: E501
        self.__exec = None
        self._env = None
        self._plain_file = None
        self._json_file = None
        self._registry = None
        self._noop = None
        self.discriminator = None
        if _exec is not None:
            self._exec = _exec
        if env is not None:
            self.env = env
        if plain_file is not None:
            self.plain_file = plain_file
        if json_file is not None:
            self.json_file = json_file
        if registry is not None:
            self.registry = registry
        if noop is not None:
            self.noop = noop

    @property
    def _exec(self):
        """Gets the _exec of this Target.  # noqa: E501


        :return: The _exec of this Target.  # noqa: E501
        :rtype: ModelExec
        """
        return self.__exec

    @_exec.setter
    def _exec(self, _exec):
        """Sets the _exec of this Target.


        :param _exec: The _exec of this Target.  # noqa: E501
        :type: ModelExec
        """

        self.__exec = _exec

    @property
    def env(self):
        """Gets the env of this Target.  # noqa: E501


        :return: The env of this Target.  # noqa: E501
        :rtype: Env
        """
        return self._env

    @env.setter
    def env(self, env):
        """Sets the env of this Target.


        :param env: The env of this Target.  # noqa: E501
        :type: Env
        """

        self._env = env

    @property
    def plain_file(self):
        """Gets the plain_file of this Target.  # noqa: E501


        :return: The plain_file of this Target.  # noqa: E501
        :rtype: PlainFile
        """
        return self._plain_file

    @plain_file.setter
    def plain_file(self, plain_file):
        """Sets the plain_file of this Target.


        :param plain_file: The plain_file of this Target.  # noqa: E501
        :type: PlainFile
        """

        self._plain_file = plain_file

    @property
    def json_file(self):
        """Gets the json_file of this Target.  # noqa: E501


        :return: The json_file of this Target.  # noqa: E501
        :rtype: JSONFile
        """
        return self._json_file

    @json_file.setter
    def json_file(self, json_file):
        """Sets the json_file of this Target.


        :param json_file: The json_file of this Target.  # noqa: E501
        :type: JSONFile
        """

        self._json_file = json_file

    @property
    def registry(self):
        """Gets the registry of this Target.  # noqa: E501


        :return: The registry of this Target.  # noqa: E501
        :rtype: Registry
        """
        return self._registry

    @registry.setter
    def registry(self, registry):
        """Sets the registry of this Target.


        :param registry: The registry of this Target.  # noqa: E501
        :type: Registry
        """

        self._registry = registry

    @property
    def noop(self):
        """Gets the noop of this Target.  # noqa: E501


        :return: The noop of this Target.  # noqa: E501
        :rtype: list[Noop]
        """
        return self._noop

    @noop.setter
    def noop(self, noop):
        """Sets the noop of this Target.


        :param noop: The noop of this Target.  # noqa: E501
        :type: list[Noop]
        """

        self._noop = noop

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
        if issubclass(Target, dict):
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
        if not isinstance(other, Target):
            return False

        return self.__dict__ == other.__dict__

    def __ne__(self, other):
        """Returns true if both objects are not equal"""
        return not self == other