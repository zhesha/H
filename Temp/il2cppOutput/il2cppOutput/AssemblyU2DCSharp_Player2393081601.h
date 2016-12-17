#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// UnityEngine.Rigidbody2D
struct Rigidbody2D_t1743771669;

#include "UnityEngine_UnityEngine_MonoBehaviour667441552.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Player
struct  Player_t2393081601  : public MonoBehaviour_t667441552
{
public:
	// UnityEngine.Rigidbody2D Player::rb
	Rigidbody2D_t1743771669 * ___rb_2;
	// System.Boolean Player::onGround
	bool ___onGround_3;
	// System.Single Player::jumpVelocity
	float ___jumpVelocity_4;

public:
	inline static int32_t get_offset_of_rb_2() { return static_cast<int32_t>(offsetof(Player_t2393081601, ___rb_2)); }
	inline Rigidbody2D_t1743771669 * get_rb_2() const { return ___rb_2; }
	inline Rigidbody2D_t1743771669 ** get_address_of_rb_2() { return &___rb_2; }
	inline void set_rb_2(Rigidbody2D_t1743771669 * value)
	{
		___rb_2 = value;
		Il2CppCodeGenWriteBarrier(&___rb_2, value);
	}

	inline static int32_t get_offset_of_onGround_3() { return static_cast<int32_t>(offsetof(Player_t2393081601, ___onGround_3)); }
	inline bool get_onGround_3() const { return ___onGround_3; }
	inline bool* get_address_of_onGround_3() { return &___onGround_3; }
	inline void set_onGround_3(bool value)
	{
		___onGround_3 = value;
	}

	inline static int32_t get_offset_of_jumpVelocity_4() { return static_cast<int32_t>(offsetof(Player_t2393081601, ___jumpVelocity_4)); }
	inline float get_jumpVelocity_4() const { return ___jumpVelocity_4; }
	inline float* get_address_of_jumpVelocity_4() { return &___jumpVelocity_4; }
	inline void set_jumpVelocity_4(float value)
	{
		___jumpVelocity_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
