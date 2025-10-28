// This code was auto-generated. Do not modify it.

#include "Engine/Scripting/BinaryModule.h"
#include "ExtensionMethods.Gen.h"

StaticallyLinkedBinaryModuleInitializer StaticallyLinkedBinaryModuleExtensionMethods(GetBinaryModuleExtensionMethods);

extern "C" BinaryModule* GetBinaryModuleExtensionMethods()
{
    static NativeBinaryModule module("ExtensionMethods");
    return &module;
}
