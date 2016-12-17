#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>


#include "UnityEngine_UnityEngine_MonoBehaviour667441552.h"
#include "UnityEngine_UnityEngine_Vector34282066566.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ScrollBG
struct  ScrollBG_t3957445618  : public MonoBehaviour_t667441552
{
public:
	// System.Single ScrollBG::speed
	float ___speed_2;
	// System.Single ScrollBG::size
	float ___size_3;
	// UnityEngine.Vector3 ScrollBG::startPosition
	Vector3_t4282066566  ___startPosition_4;

public:
	inline static int32_t get_offset_of_speed_2() { return static_cast<int32_t>(offsetof(ScrollBG_t3957445618, ___speed_2)); }
	inline float get_speed_2() const { return ___speed_2; }
	inline float* get_address_of_speed_2() { return &___speed_2; }
	inline void set_speed_2(float value)
	{
		___speed_2 = value;
	}

	inline static int32_t get_offset_of_size_3() { return static_cast<int32_t>(offsetof(ScrollBG_t3957445618, ___size_3)); }
	inline float get_size_3() const { return ___size_3; }
	inline float* get_address_of_size_3() { return &___size_3; }
	inline void set_size_3(float value)
	{
		___size_3 = value;
	}

	inline static int32_t get_offset_of_startPosition_4() { return static_cast<int32_t>(offsetof(ScrollBG_t3957445618, ___startPosition_4)); }
	inline Vector3_t4282066566  get_startPosition_4() const { return ___startPosition_4; }
	inline Vector3_t4282066566 * get_address_of_startPosition_4() { return &___startPosition_4; }
	inline void set_startPosition_4(Vector3_t4282066566  value)
	{
		___startPosition_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
