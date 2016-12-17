﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// System.Object
struct Il2CppObject;
// System.String
struct String_t;
// UnityEngine.Vector3
struct Vector3_t4282066566;
struct Vector3_t4282066566_marshaled_pinvoke;
struct Vector3_t4282066566_marshaled_com;

#include "codegen/il2cpp-codegen.h"
#include "UnityEngine_UnityEngine_Vector34282066566.h"
#include "mscorlib_System_Object4170816371.h"

// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
extern "C"  void Vector3__ctor_m2926210380 (Vector3_t4282066566 * __this, float ___x0, float ___y1, float ___z2, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Int32 UnityEngine.Vector3::GetHashCode()
extern "C"  int32_t Vector3_GetHashCode_m3912867704 (Vector3_t4282066566 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.Vector3::Equals(System.Object)
extern "C"  bool Vector3_Equals_m3337192096 (Vector3_t4282066566 * __this, Il2CppObject * ___other0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String UnityEngine.Vector3::ToString()
extern "C"  String_t* Vector3_ToString_m3566373060 (Vector3_t4282066566 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector3 UnityEngine.Vector3::get_left()
extern "C"  Vector3_t4282066566  Vector3_get_left_m1616598929 (Il2CppObject * __this /* static, unused */, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
extern "C"  Vector3_t4282066566  Vector3_op_Addition_m695438225 (Il2CppObject * __this /* static, unused */, Vector3_t4282066566  ___a0, Vector3_t4282066566  ___b1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
extern "C"  Vector3_t4282066566  Vector3_op_Multiply_m973638459 (Il2CppObject * __this /* static, unused */, Vector3_t4282066566  ___a0, float ___d1, const MethodInfo* method) IL2CPP_METHOD_ATTR;

// Methods for marshaling
struct Vector3_t4282066566;
struct Vector3_t4282066566_marshaled_pinvoke;

extern "C" void Vector3_t4282066566_marshal_pinvoke(const Vector3_t4282066566& unmarshaled, Vector3_t4282066566_marshaled_pinvoke& marshaled);
extern "C" void Vector3_t4282066566_marshal_pinvoke_back(const Vector3_t4282066566_marshaled_pinvoke& marshaled, Vector3_t4282066566& unmarshaled);
extern "C" void Vector3_t4282066566_marshal_pinvoke_cleanup(Vector3_t4282066566_marshaled_pinvoke& marshaled);

// Methods for marshaling
struct Vector3_t4282066566;
struct Vector3_t4282066566_marshaled_com;

extern "C" void Vector3_t4282066566_marshal_com(const Vector3_t4282066566& unmarshaled, Vector3_t4282066566_marshaled_com& marshaled);
extern "C" void Vector3_t4282066566_marshal_com_back(const Vector3_t4282066566_marshaled_com& marshaled, Vector3_t4282066566& unmarshaled);
extern "C" void Vector3_t4282066566_marshal_com_cleanup(Vector3_t4282066566_marshaled_com& marshaled);
