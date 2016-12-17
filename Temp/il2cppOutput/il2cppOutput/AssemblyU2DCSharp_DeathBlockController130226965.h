#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// UnityEngine.GameObject
struct GameObject_t3674682005;

#include "UnityEngine_UnityEngine_MonoBehaviour667441552.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DeathBlockController
struct  DeathBlockController_t130226965  : public MonoBehaviour_t667441552
{
public:
	// UnityEngine.GameObject DeathBlockController::deathBlock
	GameObject_t3674682005 * ___deathBlock_2;
	// System.Single DeathBlockController::spawnWait
	float ___spawnWait_3;

public:
	inline static int32_t get_offset_of_deathBlock_2() { return static_cast<int32_t>(offsetof(DeathBlockController_t130226965, ___deathBlock_2)); }
	inline GameObject_t3674682005 * get_deathBlock_2() const { return ___deathBlock_2; }
	inline GameObject_t3674682005 ** get_address_of_deathBlock_2() { return &___deathBlock_2; }
	inline void set_deathBlock_2(GameObject_t3674682005 * value)
	{
		___deathBlock_2 = value;
		Il2CppCodeGenWriteBarrier(&___deathBlock_2, value);
	}

	inline static int32_t get_offset_of_spawnWait_3() { return static_cast<int32_t>(offsetof(DeathBlockController_t130226965, ___spawnWait_3)); }
	inline float get_spawnWait_3() const { return ___spawnWait_3; }
	inline float* get_address_of_spawnWait_3() { return &___spawnWait_3; }
	inline void set_spawnWait_3(float value)
	{
		___spawnWait_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
