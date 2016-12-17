#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>


#include "UnityEngine_UnityEngine_MonoBehaviour667441552.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DeathBlock
struct  DeathBlock_t1819510425  : public MonoBehaviour_t667441552
{
public:
	// System.Single DeathBlock::speed
	float ___speed_2;
	// System.Single DeathBlock::lifetime
	float ___lifetime_3;

public:
	inline static int32_t get_offset_of_speed_2() { return static_cast<int32_t>(offsetof(DeathBlock_t1819510425, ___speed_2)); }
	inline float get_speed_2() const { return ___speed_2; }
	inline float* get_address_of_speed_2() { return &___speed_2; }
	inline void set_speed_2(float value)
	{
		___speed_2 = value;
	}

	inline static int32_t get_offset_of_lifetime_3() { return static_cast<int32_t>(offsetof(DeathBlock_t1819510425, ___lifetime_3)); }
	inline float get_lifetime_3() const { return ___lifetime_3; }
	inline float* get_address_of_lifetime_3() { return &___lifetime_3; }
	inline void set_lifetime_3(float value)
	{
		___lifetime_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
